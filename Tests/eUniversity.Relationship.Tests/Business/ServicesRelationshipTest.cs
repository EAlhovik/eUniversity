using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using eUniversity.Business.Services;
using eUniversity.Relationship.Tests.Base;

namespace eUniversity.Relationship.Tests.Business
{
    [TestFixture]
    public class ServicesRelationshipTest : GeneralReletionshipTest
    {
        protected override Assembly TestAssembly
        {
            get
            {
                return typeof (CurriculumService).Assembly;
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
                    "eUniversity.Business.Helpers",
                    "eUniversity.Data.Contracts",
                    "eUniversity.Data.Entities",
                };
            }
        }

        protected override List<string> LinksShouldNotBe
        {
            get
            {
                return new List<string>()
                {
                    "eUniversity.Business.ViewModels",
                    "eUniversity.Business.ManagementServices",
                    "eUniversity.Business.AutoMapper",
                    "eUniversity.Data",
                };
            }
        }
    }
}
