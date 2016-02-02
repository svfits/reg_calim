using System;
using System.DirectoryServices;

namespace reg_claim4.Controllers
{
    public static class AD
    {
        static public string getUser(string uLogin, out string Name, out string Surname, out string SecondName)
        {
            string notDomain = uLogin.Remove(0, 5);
            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", notDomain);
            string domain = "isea.ru";
            string[] properties = new string[] { "fullname" };
            string displayName;
            string[] BigName;
            try
            {

                DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + domain, null, null, AuthenticationTypes.Secure);
                DirectorySearcher searcher = new DirectorySearcher(adRoot);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.ReferralChasing = ReferralChasingOption.All;
                searcher.PropertiesToLoad.AddRange(properties);
                searcher.Filter = filter;

                SearchResult result = searcher.FindOne();
                DirectoryEntry directoryEntry = result.GetDirectoryEntry();

                displayName = directoryEntry.Properties["displayName"][0].ToString();
                BigName = displayName.Split(' ');
                Name = BigName[0];
                Surname = BigName[1];
                SecondName = BigName[2];
                return BigName[1] + " " + BigName[2];
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                Name = "";
                Surname = "";
                SecondName = "";
                return " ";
            }

        }

        static public void getGrups(string username, string group_Admin)
        {
            try
            {
                //   string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", "afanasievdv");
                string domain = "isea.ru";
                string[] properties = new string[] { "fullname" };
                username = "afanasievdv";

                DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + domain, null, null, AuthenticationTypes.Secure);
                DirectorySearcher dirsearcher = new DirectorySearcher(adRoot);
                dirsearcher.Filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", username);
                dirsearcher.PropertiesToLoad.Add("memberOf");
                int propCount;

                SearchResult dirSearchResults = dirsearcher.FindOne();
                propCount = dirSearchResults.Properties["memberOf"].Count;

                DirectoryEntry directoryEntry = dirSearchResults.GetDirectoryEntry();
                //  string dn, equalsIndex, commaIndex;
                PropertyValueCollection groups = directoryEntry.Properties["memberOf"];
                foreach (string g in groups)
                {
                    string group = g.Split('=')[1].Split(',')[0];
                    System.Diagnostics.Debug.WriteLine(group);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

    }
}
