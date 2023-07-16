using ImGuiNET;
using System.Diagnostics;
using Veldrid.StartupUtilities;
using Veldrid;
using Veldrid.Sdl2;
using System.Numerics;

namespace ImGuiTemplate.UiBackend;

public class App
{
    private static Sdl2Window _window;
    private static GraphicsDevice _graphicsDevice;
    private static CommandList _commandList;
    private static ImGuiController _controller;

    private static Vector3 _clearColor = new Vector3(0.45f, 0.55f, 0.6f);

    public App(string windowName)
    {
        VeldridStartup.CreateWindowAndGraphicsDevice(
            new WindowCreateInfo(50, 50, 1920, 1080, WindowState.Normal, windowName),
            new GraphicsDeviceOptions(true, null, true, ResourceBindingModel.Improved, true, true),
            out _window,
            out _graphicsDevice);

        _window.Resized += () =>
        {
            _graphicsDevice.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
            _controller.WindowResized(_window.Width, _window.Height);
        };

        _commandList = _graphicsDevice.ResourceFactory.CreateCommandList();
        _controller = new ImGuiController(_graphicsDevice, _graphicsDevice.MainSwapchain.Framebuffer.OutputDescription, _window, _window.Width, _window.Height);

        var stopwatch = Stopwatch.StartNew();
    }

    public async Task<bool> SetWindowFunction(Action action)
    {
        var stopwatch = Stopwatch.StartNew();

        while (_window.Exists)
        {
            var deltaTime = stopwatch.ElapsedTicks / (float)Stopwatch.Frequency;
            stopwatch.Restart();
            InputSnapshot snapshot = _window.PumpEvents();
            if (!_window.Exists)
            {
                break;
            }

            _controller.Update(deltaTime, snapshot);

            action.Invoke();

            _commandList.Begin();
            _commandList.SetFramebuffer(_graphicsDevice.MainSwapchain.Framebuffer);
            _commandList.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 1f));
            _controller.Render(_graphicsDevice, _commandList);
            _commandList.End();
            _graphicsDevice.SubmitCommands(_commandList);
            _graphicsDevice.SwapBuffers(_graphicsDevice.MainSwapchain);
            _controller.SwapExtraWindows(_graphicsDevice);
        }

        return true;
    }
}
