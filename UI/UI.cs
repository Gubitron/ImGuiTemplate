using ImGuiNET;
using ImGuiTemplate.UI.Views;

namespace ImGuiTemplate.UI;

public static class UI
{
    public static void Run()
    {
        ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());

        MainMenu();
    }

    public static void MainMenu()
    {
        ImGui.BeginMainMenuBar();

        MainMenuView.FileMenu();
        MainMenuView.EditMenu();

        ImGui.EndMainMenuBar();
    }
}
