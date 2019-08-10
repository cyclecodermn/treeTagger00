using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Data.Models;

namespace Tagger.Data.Repos
{
    public class TagCatsRepoDapper
    {
        public IEnumerable<TagCatsTableRow> GetAll()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = "Server=ALEXANDRA\\SQLEXPRESS;Database=TaggerTree00;Trusted_Connection=True;";
                //cn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                IEnumerable<TagCatsTableRow> returnVar = cn.Query<TagCatsTableRow>("GetAllTagTable",
                    commandType: CommandType.StoredProcedure);
                return returnVar;

                //return cn.Query<TagCatsTableRow>("GetAllTagTable",
                //    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
