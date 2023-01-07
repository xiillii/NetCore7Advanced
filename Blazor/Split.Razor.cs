using Microsoft.AspNetCore.Components;
using NetCore7Advanced.Models;

namespace NetCore7Advanced.Blazor
{
    public partial class Split
    {
        [Inject] public DataContext Context { get; set; }

        public IEnumerable<string> Names => Context.People.Select(p => p.Firstname);
    }
}
