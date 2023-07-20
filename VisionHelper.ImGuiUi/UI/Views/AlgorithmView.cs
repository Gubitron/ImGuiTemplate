namespace VisionHelper.ImGuiUi.UI.Views;

public partial class UserInterface
{
    public void AlgorithmTree()
    {
        ImGui.Begin("Algorithm");

        ImGui.BeginTable("Steps", 4);
        ImGui.TableSetupColumn("Name");
        ImGui.TableSetupColumn("Descriptions");
        ImGui.TableSetupColumn("Type");
        ImGui.TableSetupColumn("Size");
        ImGui.TableHeadersRow();

        ImGui.TableNextColumn();
        ImGui.TableNextRow();
        ImGui.TreeNode("Note:");
        ImGui.TableNextRow();
        ImGui.TreeNodeEx("Command1");

        ImGui.EndTable();

        ImGui.End();
    }
}
