using NetCore7Advanced.Blazor;
using Microsoft.JSInterop;

namespace NetCore7Advanced.Advanced.Services;

public class ToggleService
{
    private List<MultiNavLink> _components = new List<MultiNavLink>();
    private bool _enabled = true;

    public void EnrolComponents(IEnumerable<MultiNavLink> comps) => _components.AddRange(comps);

    [JSInvokable]
    public bool ToggleComponents()
    {
        _enabled = !_enabled;
        _components.ForEach(c => c.SetEnabled(_enabled));
        return _enabled;
    }
}