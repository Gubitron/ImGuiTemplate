using ImGuiNET;

namespace ImGuiTemplate.UI.Views;

public static partial class UI
{
    public static void Run()
    {
        ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());

        MainMenu();
    }

    public static void MainMenu()
    {
        ImGui.BeginMainMenuBar();
        
        FileMenu();
        EditMenu();
        ViewMenu();
        ToolsMenu();
        HelpMenu();

        ImGui.EndMainMenuBar();
    }
}
