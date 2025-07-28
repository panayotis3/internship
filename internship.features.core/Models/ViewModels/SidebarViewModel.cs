namespace internship.features.core.Models.ViewModels
{
    public class SidebarViewModel
    {
        public IEnumerable<Team>? Teams { get; set; }
        public IEnumerable<Tournament>? Tournaments { get; set; }
    }
}
