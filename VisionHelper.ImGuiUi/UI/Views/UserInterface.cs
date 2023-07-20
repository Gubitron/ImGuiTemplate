namespace VisionHelper.ImGuiUi.UI.Views;

public partial class UserInterface
{
    public void Run()
    {
        ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());
        
        MainMenu();
    }

    private void MainMenu()
    {
        ImGui.BeginMainMenuBar();
        FileMenu();
        EditMenu();
        ViewMenu();
        ToolsMenu();
        HelpMenu();
        ImGui.EndMainMenuBar();

        AlgorithmTree();

        ShowPopups();
        OptionsPopup();

        ImGui.ShowDebugLogWindow();
        ImGui.ShowAboutWindow();
        ImGui.ShowDemoWindow();
    }
}
