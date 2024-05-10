using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using EntityFrameworkCore.Projectables;
using System.ComponentModel.DataAnnotations;

namespace ProjectablesTest.Module.BusinessObjects;

[DefaultClassOptions]
public class TestObject : BaseObject {
    [MaxLength(100)]
    public virtual string FirstName { get; set; }

    [MaxLength(100)]
    public virtual string LastName { get; set; }

    [Projectable] public string FullName => FirstName + " " + LastName;
}
