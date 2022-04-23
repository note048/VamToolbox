using System.Collections.Generic;
using System.Linq;

namespace VamRepacker.Models;

public sealed class VarPackageFile : FileReferenceBase
{
    public VarPackage ParentVar { get; internal set; }

    private readonly List<VarPackageFile> _children = new();
    public override IReadOnlyCollection<VarPackageFile> Children => _children.AsReadOnly();
    public List<JsonFile> JsonFiles { get; } = new();

    public VarPackageFile(string localPath, long size)
        : base(localPath, size)
    {
    }

    public override void AddChildren(FileReferenceBase children)
    {
        _children.Add((VarPackageFile) children);
        children.ParentFile = this;
    }

    public IEnumerable<VarPackageFile> SelfAndChildren()
    {
        return Children == null ? new[] { this } : Children.Concat(new[] { this });
    }

    public override string ToString()
    {
        return base.ToString() + $" Var: {ParentVar.Name.Filename}";
    }
}