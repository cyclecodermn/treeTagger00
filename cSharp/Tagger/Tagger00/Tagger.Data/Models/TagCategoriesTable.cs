using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Data.Models
{
    public class TagCatsTableRow
    {
        public int TagNameId { get; set; }
        public int TagParentId { get; set; }
        public string TagName { get; set; }
        public DateTime TagAddedDate { get; set; }
    }
}
