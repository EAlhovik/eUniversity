using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace eUniversity.Relationship.Tests.Base
{
    public abstract class GeneralReletionshipTest
    {
        protected abstract List<string> LinksShouldBe
        {
            get;
        }

        protected abstract List<string> LinksShouldNotBe
        {
            get;
        }

        protected abstract Assembly TestAssembly
        {
            get;
        }

        [Test]
        public void ShouldNotBeReferences()
        {
            var referencedAssemblies = TestAssembly.GetReferencedAssemblies();

            var foundAssemlyes = referencedAssemblies.Where(x => LinksShouldNotBe.Contains(x.Name));
            
            Assert.AreEqual(0, foundAssemlyes.Count());
        }

        [Test]
        public void ShouldBeReferences()
        {
            var referencedAssemblies = TestAssembly.GetReferencedAssemblies();

            var foundAssemlyes = referencedAssemblies.Where(x => LinksShouldBe.Contains(x.Name));

            Assert.AreEqual(LinksShouldBe.Count(), foundAssemlyes.Count());
        }
    }
}