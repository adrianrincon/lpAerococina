using System;
namespace Aerococina.Models
{
    public class MenuMenuItem
    {
        public MenuMenuItem()
        {
            TargetType = typeof(Views.MenuDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
