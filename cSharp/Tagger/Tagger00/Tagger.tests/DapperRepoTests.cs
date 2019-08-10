using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Data.Models;
using Tagger.Data.Repos;

namespace Tagger.tests
{
    [TestFixture]
    public class DapperRepoTests
    {
        [Test]
        public void CanLoadAllTags()
        {
            TagCatsRepoDapper repo = new TagCatsRepoDapper();
            IEnumerable<TagCatsTableRow> allCats = repo.GetAll();
            Assert.AreEqual(16, allCats.Count());

        }

    }
}
