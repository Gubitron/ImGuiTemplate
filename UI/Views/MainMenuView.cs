using ImGuiNET;

namespace ImGuiTemplate.UI.Views;

public static partial class UI
{
    private static void FileMenu()
    {
        if (ImGui.BeginMenu("File"))
        {
            if (ImGui.MenuItem("New File"))
            {
                
            }

            if (ImGui.MenuItem("Open File"))
            {

            }

            if (ImGui.MenuItem("Close File"))
            {

            }

            if (ImGui.MenuItem("Close All Files"))
            {

            }

            ImGui.Separator();

            if (ImGui.MenuItem("Save File"))
            {

            }

            if (ImGui.MenuItem("Save File As..."))
            {

            }

            if (ImGui.MenuItem("Save All Files"))
            {

            }

            ImGui.Separator();

            if (ImGui.MenuItem("Recent Files"))
            {

            }

            ImGui.Separator();

            if (ImGui.MenuItem("Exit"))
            {

            }

            ImGui.EndMenu();
        }
    }

    public static void EditMenu()
    {
        if (ImGui.BeginMenu("Edit"))
        {
            if (ImGui.MenuItem("Undo"))
            {

            }

            if (ImGui.MenuItem("Redo"))
            {

            }

            ImGui.Separator();

            if (ImGui.MenuItem("Copy"))
            {

            }

            if (ImGui.MenuItem("Paste"))
            {

            }

            if (ImGui.MenuItem("Duplicate"))
            {

            }

            if (ImGui.MenuItem("Delete"))
            {

            }

            ImGui.Separator();

            if (ImGui.MenuItem("Select All"))
            {

            }

            ImGui.EndMenu();
        }
    }

    public static void ViewMenu()
    {
        if (ImGui.BeginMenu("View"))
        {
            if (ImGui.BeginMenu("Windows"))
            {
                if (ImGui.MenuItem("Camera View"))
                {

                }

                if (ImGui.MenuItem("Variable View"))
                {

                }

                if (ImGui.MenuItem("Diagnostics View"))
                {

                }

                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Toolbars"))
            {
                if (ImGui.MenuItem("Toolbar1"))
                {

                }

                if (ImGui.MenuItem("Toolbar2"))
                {

                }

                ImGui.EndMenu();
            }

            ImGui.Separator();

            if (ImGui.MenuItem("Logs"))
            {

            }

            ImGui.EndMenu();
        }
    }

    public static void ToolsMenu()
    {
        if (ImGui.BeginMenu("Tools"))
        {
            if (ImGui.BeginMenu("Theme"))
            {
                if (ImGui.MenuItem("Dark Theme"))
                {

                }

                if (ImGui.MenuItem("Light Theme"))
                {

                }

                ImGui.EndMenu();
            }

            ImGui.Separator();

            if (ImGui.MenuItem("Options"))
            {
                OptionsWindow();
            }

            ImGui.EndMenu();
        }
    }

    public static void HelpMenu()
    {
        if (ImGui.BeginMenu("Help"))
        {
            if (ImGui.MenuItem("Documentation"))
            {

            }

            if (ImGui.MenuItem("Help Dialog"))
            {

            }

            if (ImGui.MenuItem("Examples"))
            {

            }

            ImGui.Separator();

            if (ImGui.MenuItem("About"))
            {

            }

            ImGui.EndMenu();
        }
    }
}
