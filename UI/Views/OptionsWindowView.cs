using ImGuiNET;

namespace ImGuiTemplate.UI.Views;

public static partial class UI
{
    public static void OptionsWindow()
    {
        ImGui.BeginPopupContextWindow();
        ImGui.Text("Testas");
        ImGui.End();
    }

}
