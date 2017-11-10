using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace JARVIS6
{
    public class JARVISCryptography
    {
        private JARVISDataSource DataSource { get; set; }
        private Dictionary<string, string> SqlServerHashTypes = new Dictionary<string, string>()
        {
            {"MD5", "32"},
            {"SHA", "40"},
            {"SHA1", "40"},
            {"SHA2_256", "64"},
            {"SHA2_512", "128"}
        };
        private string ASCIICharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890~`!@#$%^&*()_+-={}[]:\"|;'\\<>?,./";
        public JARVISCryptography()
        {

        }
        public StatusObject SetDataSource(string Server, string Database, string UserID, string Password)
        {
            StatusObject SO = new StatusObject();
            try
            {
                
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "JARVISCRYPTOGRAPHY_SETDATASOURCE_01");
            }
            return SO;
        }
        public StatusObject CreateRainbowTable(string HashType, string WordLength)
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject PopulateRainbowTable()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject ClearRainbowTable()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
