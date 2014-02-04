using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using eUniversity.Business.Services;

namespace eUniversity.Relationship.Tests.Services
{
    [TestFixture]
    public class ServicesRelationshipTests
    {
        [Test]
        public void ShouldNotBeReferences()
        {
            var assembly = GetAssemblyContainingType<CurriculumService>();
            var referencedAssemblies = assembly.GetReferencedAssemblies();
            var assemblyNames = new List<string>()
                {
                    "eUniversity.Business.ViewModels",
                    "eUniversity.Business.ManagementServices",
                    "eUniversity.Business.AutoMapper",
                    "eUniversity.Data",
                };

            var foundAssemlyes = referencedAssemblies.Where(x => assemblyNames.Contains(x.Name));


            Assert.AreEqual(0, foundAssemlyes.Count());
        }

        [Test]
        public void ShouldBeReferences()
        {
            var assembly = GetAssemblyContainingType<CurriculumService>();
            var referencedAssemblies = assembly.GetReferencedAssemblies();
            var assemblyNames = new List<string>()
                {
                    "eUniversity.Business.Domain.Contracts",
                    "eUniversity.Business.Domain.Entities",
                    "eUniversity.Business.Helpers",
                    "eUniversity.Data.Contracts",
                };
            var foundAssemlyes = referencedAssemblies.Where(x => assemblyNames.Contains(x.Name));

            Assert.AreEqual(assemblyNames.Count(), foundAssemlyes.Count());
        }

        private static Assembly GetAssemblyContainingType<T>()
        {
            return (typeof(T).Assembly);
        }
    }
}
