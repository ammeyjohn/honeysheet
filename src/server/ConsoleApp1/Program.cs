using Novell.Directory.Ldap;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string BaseDC = "DC=shanghai3h;DC=com";
            using (var conn = new LdapConnection())
            {
                conn.Connect("128.1.1.20", 389);
                conn.Bind($"CN=袁杰;OU=公司员工;DC=shanghai3h;DC=com", "2345678901");

                var result = conn.Search("OU=公司员工,DC=shanghai3h,DC=com", LdapConnection.SCOPE_ONE,
                    "(name=*)", null, false);

                while (result.hasMore())
                {
                    LdapEntry nextEntry = null;
                    try
                    {
                        nextEntry = result.next();
                        Console.WriteLine("\n" + nextEntry.DN);
                    }
                    catch (LdapException e)
                    {
                        Console.WriteLine("Error: " + e.LdapErrorMessage);
                        //Exception is thrown, go for next entry
                        continue;
                    }
                }
            }
            
            Console.ReadLine();
        }
    }
}
