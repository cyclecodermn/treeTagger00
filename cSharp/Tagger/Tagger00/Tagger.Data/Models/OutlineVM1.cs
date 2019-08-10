using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Data.Models
{
    public class OutlineVM1
    {
        public List<int> TagId { get; set; }
        public List<int> ParentId { get; set; }
        public string TagName { get; set; }
    }
}
