using System.ComponentModel;

namespace eUniversity.Business.Helpers.Enums
{
    public enum AccountTypeEnum
    {
        [Description("Студент")]
        Student,

        [Description("Преподаватель")]
        Professor
    }
}