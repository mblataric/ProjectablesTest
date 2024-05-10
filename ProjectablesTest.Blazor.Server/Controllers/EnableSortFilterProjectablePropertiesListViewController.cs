using DevExpress.Blazor;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp;
using EntityFrameworkCore.Projectables;
using System.Reflection;
using System.Security.Principal;

namespace ProjectablesTest.Blazor.Server.Controllers;

public class EnableSortFilterProjectablePropertiesListViewController : ObjectViewController<ListView, object> {
    protected override void OnViewControlsCreated() {
        base.OnViewControlsCreated();
        if (View.Editor is not DxGridListEditor gridListEditor) return;
        var dataGridAdapter = gridListEditor.GetGridAdapter();
        foreach (var columnModel in dataGridAdapter.GridDataColumnModels) {
            var property = View.ObjectTypeInfo.Type.GetMember(columnModel.FieldName).SingleOrDefault();
            if (!property?.HasAttribute<ProjectableAttribute>() ?? true) continue;

            columnModel.AllowSort = true;
            columnModel.FilterRowEditorVisible = true;
            columnModel.FilterMenuButtonDisplayMode = GridFilterMenuButtonDisplayMode.Default;
        }
    }
}

public static class ExtClass {
    public static bool HasAttribute<T>(this MemberInfo memberInfo) {
        return Attribute.IsDefined(memberInfo, typeof(T));
    }
}