using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using eUniversity.Business.AutoMapper.Profiles;
using eUniversity.Relationship.Tests.Base;

namespace eUniversity.Relationship.Tests.Business
{
    [TestFixture]
    public class AutoMapperRelationshipTest : GeneralReletionshipTest
    {
        protected override Assembly TestAssembly
        {
            get
            {
                return typeof(UniversityProfile).Assembly;
            }
        }

        protected override List<string> LinksShouldBe
        {
            get
            {
                return new List<string>()
                {
                    "eUniversity.Business.Domain.Contracts",
                    "eUniversity.Business.Domain.Entities",
                    "eUniversity.Data.Entities",
                    "eUniversity.Business.ViewModels",
                };
            }
        }

        protected override List<string> LinksShouldNotBe
        {
            get
            {
                return new List<string>()
                {
                    "eUniversity.Business.Helpers",
                    "eUniversity.Data.Contracts",
                    "eUniversity.Business.ManagementServices",
                    "eUniversity.Business.AutoMapper",
                    "eUniversity.Data",
                };
            }
        }
    }
}
