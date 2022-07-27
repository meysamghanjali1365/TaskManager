namespace TaskManagerSolution.Common.FileTool;
public static class DeleteFile {

    public static bool DeleteFileFromRoot(string path) {
        System.IO.File.Delete(path);
        return true;
    }
}