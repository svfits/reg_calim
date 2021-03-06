﻿
      //кому зявка
  $(function () {
      $("[data]").each(function () {
          var target = $(this);
          target.autocomplete({ source: target.attr("data") });
      });
  });


//название заявки и вставить дату
$(function () {
    $("[dataClaimeName]").each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr("dataClaimeName") });
        target.autocomplete({
            select: function (event, ui) {
                console.log(ui.item.value);                    
                dataTimeEnd(ui.item.value);
            }
        });
    });
});

//вставить время и дату 
function dataTimeEnd(date_end) {
    $.ajax({
        type: "POST",
        url: "/AddClaim/DataTimeEnd",
        data: {
            date_end: date_end
        },
        success: function (data) {           
            console.log(data);
            $('#dataTimeEnd').datetimepicker({                
                // format: 'DD.MM.YYYY HH:mm', minDate: Date(), maxDate: maxDate(data), defaultDate: "01.01.2008 16:45"
                maxDate: maxxDate(data), defaultDate: maxxDate(data), format: 'DD.MM.YYYY HH:mm', locale: 'ru'
            });
            //$('#dataTimeEnd').datetimepicker({
            //      maxDate: maxDate(data)              
            //});
        }
    });
}

function minnDate()
{
    var ret = new Date();
    var MM = ret.getMonth() + 1;
    var MM = "0" + MM;
    var DD = "0" + ret.getDay() - 1;

    tt = MM +"."+ DD + "." + ret.getFullYear() + " " + ret.getHours() + ":" + ret.getMinutes()
    console.log("минимальное время  " + tt);
   // var tt = "03.01.2016 10:12";
    return tt
}
function maxxDate(data)
{
   // console.log(data);
    if (getWeek() == 6)
    {
        var dateEnd = dateAdd(Date(), "day", 2);
        dateEnd = dateAdd(dataEnd, "minute", data)
        console.log(dateEnd);
        return dateEnd
    }
    if (getWeek() == 7)
    {
        var dateEnd = dateAdd(Date(), "day", 1);
        dateEnd = dateAdd(dataEnd, "minute", data)
        console.log(dateEnd);
        return dateEnd
    }
    if (getWeek() > 1)
    {       
        var dateEnd = dateAdd(Date(), "minute", data)
        console.log(dateEnd);
        return dateEnd
    }
}

function getWeek() {
    var date = new Date();  
    return date.getDay();
}

function dateAdd(date, interval, units) {
    var ret = new Date(date); //don't change original date
    switch (interval.toLowerCase()) {
        case 'year': ret.setFullYear(ret.getFullYear() + units); break;
        case 'quarter': ret.setMonth(ret.getMonth() + 3 * units); break;
        case 'month': ret.setMonth(ret.getMonth() + units); break;
        case 'week': ret.setDate(ret.getDate() + 7 * units); break;
        case 'day': ret.setDate(ret.getDate() + units); break;
        case 'hour': ret.setTime(ret.getTime() + units * 3600000); break;
        case 'minute': ret.setTime(ret.getTime() + units * 60000); break;
        case 'second': ret.setTime(ret.getTime() + units * 1000); break;
        default: ret = undefined; break;
    }   
    return ret;
}

function getWeekDay()
{

}
// откого заявка по умолчанию тот кто открыл страницу
$(function () {
    $("[whoAmiFromClaim]").each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr("whoAmiFromClaim") });
    });
});
