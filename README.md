# Simple Log Parser (C#)

Simple CLI tool to split warning and error log entries to separate text files.

## How to Use
You run the command with the path to your log file.
```bash
dotnet run -- <path_to_log_file>
```
After that the script generates two .txt files with error and warning entries, in the same directory as the original log file.
## Highlights
- Case insensitive matching for "[Error]" and "Error:" log formats
- Preserves original line numbers for easy cross referencing
- Meaningful exit codes, 0 - No Errors or warnings detected, 1 - Argument Error, 2 - Errors detected (may also include warnings), 3 - Warnings detected
## Built With
- C# / .NET 10
