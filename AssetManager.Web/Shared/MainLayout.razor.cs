using AssetManager.Core.Interfaces.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] protected ICurrentUserService currentUserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private bool _drawerOpen = false;
        private NavMenu _navMenuRef;
        private string _username;

        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
        protected override async Task OnInitializedAsync()
        {
            _drawerOpen = true;
            var user = await currentUserService.GetCurrentUserAsync();
            _username = user?.Email;
        }


        #region Theme

        private MudTheme _currentTheme = new()
        {
            Palette = new Palette()
            {
                Primary = "#42A5F5",
                Black = "#27272F",
                Background = "#32333D",
                BackgroundGrey = "#27272F",
                Surface = "#373740",
                DrawerBackground = "#27272F",
                DrawerText = "rgba(255,255,255, 0.50)",
                DrawerIcon = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272F",
                AppbarText = "rgba(255,255,255, 0.70)",
                TextPrimary = "rgba(255,255,255, 0.70)",
                TextSecondary = "rgba(255,255,255, 0.50)",
                ActionDefault = "#ADADB1",
                ActionDisabled = "rgba(255,255,255, 0.26)",
                ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                Divider = "rgba(255,255,255, 0.12)",
                DividerLight = "rgba(255,255,255, 0.06)",
                TableLines = "rgba(255,255,255, 0.12)",
                LinesDefault = "rgba(255,255,255, 0.12)",
                LinesInputs = "rgba(255,255,255, 0.3)",
                TextDisabled = "rgba(255,255,255, 0.2)",
                Info = "#3299FF",
                Success = "#0BBA83",
                Warning = "#FFA800",
                Error = "#F64E62",
                Dark = "#27272F"
            }
        };

        #endregion
    }
}
