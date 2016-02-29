
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
            $('#dataTimeEnd').datetimepicker();
        }
    });
}

// откого заявка по умолчанию тот кто открыл страницу
$(function () {
    $("[whoAmiFromClaim]").each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr("whoAmiFromClaim") });
    });
});
