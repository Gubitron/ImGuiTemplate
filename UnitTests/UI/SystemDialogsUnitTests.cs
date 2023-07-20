

using VisionHelper.ImGuiUi.UI;

public class SystemDialogsUnitTests
{
    [Fact]
    public void FileFilters_WhenNoSeparatorSpecified_Builds()
    {
        // Act
        var actual = FileFilters.Combine(FileFilters.ALL_FILES, FileFilters.TXT, FileFilters.ALG);

        // Assert
        actual.Should().Be("All files (*.*)|*.*|txt files (*.txt)|*.txt|alg files (*.alg)|*.alg");
    }
}