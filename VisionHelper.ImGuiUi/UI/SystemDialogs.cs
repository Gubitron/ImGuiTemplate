using static System.Net.Mime.MediaTypeNames;

namespace VisionHelper.ImGuiUi.UI;

public static class SystemDialogs
{
    private const string DEFAULT_INITIAL_DIRECTORY = @"C:\";

    // Want to explicitly block execution for these methods
    public static (bool Result, string SelectedFilePath) OpenFileDialog(
        string windowTitle,
        string initialDirectory = DEFAULT_INITIAL_DIRECTORY,
        string filter = FileFilters.ALL_FILES,
        int filterIndex = 0
        )
    {
        if (OperatingSystem.IsWindows())
        {
            bool result = false;
            string selectedFilePath = string.Empty;

            var thread = new Thread((ThreadStart)(() =>
            {
                var dialog = new OpenFileDialog()
                {
                    InitialDirectory = initialDirectory,
                    Filter = filter,
                    FilterIndex = filterIndex,
                    RestoreDirectory = false,
                    CheckPathExists = true,
                    Multiselect = false,
                    Title = windowTitle
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    result = true;
                    selectedFilePath = dialog.FileName;
                }
                else
                {
                    result = false;
                    selectedFilePath = string.Empty;
                }
            }));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return (result, selectedFilePath);
        }
        else
        {
            throw new NotSupportedException("File dialog only supported for Windows!");
        }
    }

    public static (bool Result, string SelectedFilePath) SaveFileDialog(
        string windowTitle,
        string initialDirectory = DEFAULT_INITIAL_DIRECTORY,
        string filter = FileFilters.ALL_FILES,
        int filterIndex = 0)
    {
        if (OperatingSystem.IsWindows())
        {
            bool result = false;
            string selectedFilePath = string.Empty;

            var thread = new Thread((ThreadStart)(() =>
            {
                var dialog = new OpenFileDialog()
                {
                    InitialDirectory = initialDirectory,
                    Filter = filter,
                    FilterIndex = filterIndex,
                    RestoreDirectory = false,
                    CheckPathExists = true,
                    Multiselect = false,
                    Title = windowTitle
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    result = true;
                    selectedFilePath = dialog.FileName;
                }
                else
                {
                    result = false;
                    selectedFilePath = string.Empty;
                }
            }));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return (result, selectedFilePath);
        }
        else
        {
            throw new NotSupportedException("File dialog only supported for Windows!");
        }
    }
}

public static class FileFilters
{
    public const string ALL_FILES = "All files (*.*)|*.*";
    public const string TXT = "txt files (*.txt)|*.txt";
    public const string ALG = "alg files (*.alg)|*.alg";

    public static string Combine(params string[] filters)
    {
        return string.Join("|", filters);
    }
}

public static class FileExtensions
{
    public const string TXT = "txt";
    public const string ALG = "alg";

}
