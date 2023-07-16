using ImGuiNET;

namespace ImGuiTemplate.UI.Views;

public static class MainMenuView
{
    public static void FileMenu()
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

            if (ImGui.MenuItem("Save File"))
            {

            }

            if (ImGui.MenuItem("Save File As..."))
            {

            }

            if (ImGui.MenuItem("Save All Files"))
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

            ImGui.EndMenu();
        }
    }
}
