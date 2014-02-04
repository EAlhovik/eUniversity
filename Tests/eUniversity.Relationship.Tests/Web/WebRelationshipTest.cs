using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using eUniversity.Relationship.Tests.Base;
using eUniversity.Web.Controllers;

namespace eUniversity.Relationship.Tests.Web
{
    [TestFixture]
    public class WebRelationshipTest : GeneralReletionshipTest
    {
        protected override Assembly TestAssembly
        {
            get
            {
                return typeof(AccountController).Assembly;
            }
        }

        protected override List<string> LinksShouldBe
        {
            get
            {
                return new List<string>()
                {
                    "eUniversity.Business.Domain.Contracts",
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
                    "eUniversity.Business.Domain.Entities",
                    "eUniversity.Business.AutoMapper",
                    "eUniversity.Business.Helpers",
                    "eUniversity.Business.ManagementServices",
                    "eUniversity.Business.Services",
                    "eUniversity.Common.Utilities",
                    "eUniversity.Data",
                    "eUniversity.Data.Contracts",
                    "eUniversity.Relationship.Tests",
                    "eUniversity.Tests",
                };
            }
        }
    }
}