namespace VisionHelper.ImGuiUi.UI.Views;

public partial class UserInterface
{
    public bool showOptionsPopup;

    public void ShowPopups()
    {
        if (showOptionsPopup)
        {
            ImGui.OpenPopup("Options");
        }
    }

    public void OptionsPopup()
    {
        if (ImGui.BeginPopupModal("Options"))
        {
            ImGui.Text("These are options:");

            ImGui.Text("Setting1:");

            var test = new byte[1024];
            ImGui.InputText("label", test, (uint)test.Length);

            if (ImGui.Button("Close"))
            {
                showOptionsPopup = false;
                ImGui.CloseCurrentPopup();
            }
            ImGui.EndPopup();
        }
    }

}
