using System.Diagnostics;
using System.Numerics;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;
using ImGuiNET;

using static ImGuiNET.ImGuiNative;
using ImGuiTemplate.UiBackend;
using ImGuiTemplate.UI.Views;

namespace ImGuiTesting;

internal static class Program
{
    private static Sdl2Window _window;
    private static GraphicsDevice _gd;
    private static CommandList _cl;
    private static ImGuiController _controller;

    private static Vector3 _clearColor = new Vector3(0.45f, 0.55f, 0.6f);
    private static bool _showImGuiDemoWindow = true;
    private static bool _showAnotherWindow = false;

    private static float _f = 0.0f;
    private static int _counter = 0;
    private static int _dragInt = 0;

    private const uint _backgroundColor = 0xa4ff39ed; // light purple
    private const uint _titleColor = 0x6e0ba7ed; // darker purple
    private const uint _textColor = 0x00000000; // black

    [STAThread]
    static async Task Main()
    {
        var window = new App("Test Window");
        var result = await window.SetWindowFunction(myGui).ConfigureAwait(false);
    }

    public static void myGui()
    {
        UI.Run();

        //ImGui.PushStyleColor(ImGuiCol.DockingEmptyBg, _backgroundColor);
        ////ImGui.PushStyleColor(ImGuiCol.TitleBg, _titleColor);
        ////ImGui.PushStyleColor(ImGuiCol.MenuBarBg, _titleColor);
        ////ImGui.PushStyleColor(ImGuiCol.Text, _textColor);

        //ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());

        //MainMenuBar();
        //AlgorithmWindow();
        //InfoWindow();
        ////ImGui.ShowDemoWindow();

        //ImGui.PopStyleColor(1);
    }

    private static void AlgorithmWindow()
    {
        ImGui.Begin("Algorithm");
        ImGui.GetWindowDockID();
        if (ImGui.TreeNode("Node1"))
        {
            ImGui.TreeNode("Child1");
        }
        if (ImGui.TreeNode("Node2"))
        {
            ImGui.TreeNode("Child1-2");
        }
        ImGui.End();
    }

    private static void InfoWindow()
    {
        ImGui.Begin("Info");
        float framerate = ImGui.GetIO().Framerate;
        ImGui.Text($"Frame time: {1000.0f / framerate:0.##} ms");
        ImGui.Text($"FPS: {framerate:0.#} FPS");
        ImGui.End();
    }

    private static void MainMenuBar()
    {
        ImGui.BeginMainMenuBar();
        if (ImGui.BeginMenu("File"))
        {
            ImGui.MenuItem("New File");
            ImGui.MenuItem("Open File");
            ImGui.EndMenu();
        }
        if (ImGui.BeginMenu("Edit"))
        {
            ImGui.MenuItem("Undo");
            ImGui.MenuItem("Redo");
            ImGui.EndMenu();
        }
        if (ImGui.BeginMenu("Tools"))
        {
            if (ImGui.MenuItem("Options"))
            {
                ImGui.Begin("Options");
                ImGui.LabelText("Setting1", "Helps set setting 1.");
                ImGui.End();
            }
            ImGui.EndMenu();
        }
        if (ImGui.BeginMenu("About"))
        {
            ImGui.MenuItem("History");
            ImGui.EndMenu();
        }
        ImGui.EndMainMenuBar();
    }

    private static void OptionsWindow()
    {
        ImGui.OpenPopup("Options");
        ImGui.BeginPopupModal("Options");
        ImGui.Text("Option1");
        ImGui.EndPopup();
    }
}