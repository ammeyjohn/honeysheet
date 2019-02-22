using System;
using System.DirectoryServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://128.1.1.20:389/DC=shanghai3h,DC=com",
                "CN=袁杰,OU=公司员工,DC=shanghai3h,DC=com", "2345678901", AuthenticationTypes.None);
            if(entry == null)
            {

            }
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = string.Format("(SAMAccountName={0})", "qiwe88iwei");
            search.SearchScope = SearchScope.Subtree;
            

            SearchResult result = search.FindOne();
            var prop = result.Properties["distinguishssedName"];
            Console.WriteLine(result.Path);

            var entry1 = new DirectoryEntry("LDAP://128.1.1.20:389/DC=shanghai3h,DC=com",
                prop[0].ToString(), "2345678901", AuthenticationTypes.None);
            var obj = entry1.NativeObject;
            var count = entry1.Properties.Count;
            Console.ReadLine();
        }
    }
}
