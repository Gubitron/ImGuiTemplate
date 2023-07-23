using System.Windows.Forms;
using System.Xml.Linq;

namespace VisionHelper.ImGuiUi.UI.Views;

public partial class UserInterface
{
    public void AlgorithmTree()
    {
        ImGui.Begin("Algorithms");

        var dockspaceId = ImGui.GetID("MyDockspace");
        ImGui.DockSpace(dockspaceId);

        ImGui.SetNextWindowDockID(dockspaceId);
        if (ImGui.Begin("Docked Window 1"))
        {
            ImGui.Text("Content for Docked Window 1");
            Algorithm2();
            ImGui.End();
        }

        ImGui.SetNextWindowDockID(dockspaceId);
        if (ImGui.Begin("Docked Window 2"))
        {
            ImGui.Text("Content for Docked Window 2");
            ImGui.End();
        }


        //ImGui.BeginTabBar("Algorithms");

        //if (ImGui.BeginTabItem("Fabrication1"))
        //{
        //    ImGui.EndTabItem();
        //}

        //if (ImGui.BeginTabItem("Fabrication2"))
        //{
        //    ImGui.EndTabItem();
        //}

        //if (ImGui.BeginTabItem("Fabrication3"))
        //{
        //    ImGui.EndTabItem();
        //}

        //ImGui.EndTabBar();

        ImGui.End();
    }

    public void Algorithm()
    {
        ImGuiTableFlags flags = ImGuiTableFlags.BordersV | ImGuiTableFlags.BordersOuterH | ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg | ImGuiTableFlags.NoBordersInBody;

        if (ImGui.BeginTable("3ways", 3, flags))
        {
            // The first column will use the default _WidthStretch when ScrollX is Off and _WidthFixed when ScrollX is On
            ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.NoHide);
            ImGui.TableSetupColumn("Size", ImGuiTableColumnFlags.WidthFixed, ImGui.CalcTextSize("A").X * 12.0f);
            ImGui.TableSetupColumn("Type", ImGuiTableColumnFlags.WidthFixed, ImGui.CalcTextSize("A").X * 18.0f);
            ImGui.TableHeadersRow();

            // Simple storage to output a dummy file-system.
            var nodes = new List<MyTreeNode>()
            {
                new MyTreeNode()
                {
                    Name = "Name1",
                    Type = "Folder",
                    Size = -1,
                    ChildIdx = 1,
                    ChildCount = 1
                },
                new MyTreeNode()
                {
                    Name = "Name2",
                    Type = "Folder",
                    Size = -1,
                    ChildIdx = 2,
                    ChildCount = 1
                },
                new MyTreeNode()
                {
                    Name = "Name3",
                    Type = "Folder",
                    Size = -1,
                    ChildIdx = 3,
                    ChildCount = 0
                }
                //{
                //    "Root",                         "Folder",       -1,       1, 3    ), // 0
                //{ "Music",                        "Folder",       -1,       4, 2    }, // 1
                //{ "Textures",                     "Folder",       -1,       6, 3    }, // 2
                //{ "desktop.ini",                  "System file",  1024,    -1,-1    }, // 3
                //{ "File1_a.wav",                  "Audio file",   123000,  -1,-1    }, // 4
                //{ "File1_b.wav",                  "Audio file",   456000,  -1,-1    }, // 5
                //{ "Image001.png",                 "Image file",   203128,  -1,-1    }, // 6
                //{ "Copy of Image001.png",         "Image file",   203256,  -1,-1    }, // 7
                //{ "Copy of Image001 (Final2).png","Image file",   203512,  -1,-1    }, // 8
            };

            MyTreeNode.DisplayNode(nodes[0], nodes);

            ImGui.EndTable();
        }
        ImGui.TreePop();
    }

    public struct MyTreeNode
    {
        public string Name;
        public string Type;
        public int Size;
        public int ChildIdx;
        public int ChildCount;
        public static void DisplayNode(MyTreeNode node, List<MyTreeNode> all_nodes)
        {
            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            bool is_folder = (node.ChildCount > 0);
            if (is_folder)
            {
                bool open = ImGui.TreeNodeEx(node.Name, ImGuiTreeNodeFlags.SpanFullWidth);
                ImGui.TableNextColumn();
                ImGui.TextDisabled("--");
                ImGui.TableNextColumn();
                ImGui.TextUnformatted(node.Type);
                if (open)
                {
                    for (int child_n = 0; child_n < node.ChildCount; child_n++)
                        DisplayNode(all_nodes[node.ChildIdx + child_n], all_nodes);
                    ImGui.TreePop();
                }
            }
            else
            {
                ImGui.TreeNodeEx(node.Name, ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.SpanFullWidth);
                ImGui.TableNextColumn();
                ImGui.Text($"{node.Size}");
                ImGui.TableNextColumn();
                ImGui.TextUnformatted(node.Type);
            }
        }
    };

    public void Algorithm2()
    {
        ImGuiTableFlags flags = ImGuiTableFlags.BordersV | ImGuiTableFlags.BordersOuterH | ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg;// | ImGuiTableFlags.NoBordersInBody;

        if (ImGui.BeginTable("Algorithms", 3, flags))
        {
            // The first column will use the default _WidthStretch when ScrollX is Off and _WidthFixed when ScrollX is On
            ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.NoHide);
            ImGui.TableSetupColumn("Group", ImGuiTableColumnFlags.WidthFixed, ImGui.CalcTextSize("A").X * 12.0f);
            ImGui.TableSetupColumn("State", ImGuiTableColumnFlags.WidthFixed, ImGui.CalcTextSize("A").X * 18.0f);
            ImGui.TableHeadersRow();

            ImGui.TableNextRow();
            ImGui.TableNextColumn();

            if (ImGui.TreeNodeEx("Node1", ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.OpenOnDoubleClick))
            {
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                if (ImGui.TreeNodeEx("Node1-1", ImGuiTreeNodeFlags.SpanFullWidth))
                {
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    if (ImGui.TreeNodeEx("Child1", ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.SpanFullWidth))
                    {

                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }

            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            if (ImGui.TreeNodeEx("Node2", ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.OpenOnDoubleClick))
            {
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                if (ImGui.TreeNodeEx("Node2-1", ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.OpenOnDoubleClick))
                {
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    if (ImGui.TreeNodeEx("Child1", ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.SpanFullWidth))
                    {

                    }
                    ImGui.TreePop();
                }

                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                if (ImGui.TreeNodeEx("Node2-2", ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.OpenOnDoubleClick))
                {
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    if (ImGui.TreeNodeEx("Child2", ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.SpanFullWidth))
                    {
                    }
                    ImGui.TreePop();
                }

                ImGui.TreePop();
            }

            ImGui.EndTable();
        }
        ImGui.TreePop();
    }
}
