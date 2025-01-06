namespace PuzzleRunner.Day9;

public class Day9 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day9/test_input.txt"), 1928 },
        { File.ReadAllLines("Day9/puzzle_input.txt"), 6463499258318 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day9/test_input.txt"), 2858 },
        { File.ReadAllLines("Day9/puzzle_input.txt"), 6493634986625 }
    };

    public long Part1(string[] input)
    {
        var memory = ProcessInput(input);

        // PrintMemory(memory);

        for (var node = memory.First; node != null && node != memory.Last; node = node.Next)
        {
            var memorySegment = node.Value;

            if (memorySegment is FileSegment)
            {
                continue;
            }

            var freeSpaceSegment = memorySegment as FreeSpaceSegment;

            var spaceToFill = freeSpaceSegment!.Length;

            while (memory.Last?.Value is not FileSegment)
            {
                memory.RemoveLast();
            }

            var lastNode = memory.Last;

            var lastFileSegment = lastNode.Value as FileSegment;

            if (lastFileSegment!.Length > spaceToFill)
            {
                // last file is bigger than free space, update the last file size and create a new file to replace free space
                lastFileSegment.Length -= spaceToFill;
                node.Value = new FileSegment
                {
                    StartPosition = freeSpaceSegment.StartPosition,
                    Length = freeSpaceSegment.Length,
                    FileId = lastFileSegment.FileId
                };
            }
            else
            {
                // last file is not enough to fill the free space, we have to move it and create new free space to handle next

                lastFileSegment.StartPosition = freeSpaceSegment.StartPosition;

                freeSpaceSegment.Length -= lastFileSegment.Length;
                freeSpaceSegment.StartPosition += lastFileSegment.Length;


                node.Value = lastFileSegment;

                memory.AddAfter(node, freeSpaceSegment);
                memory.RemoveLast();
            }
            // PrintMemory(memory);
        }

        // PrintMemory(memory);

        return ComputeChecksum(memory);
    }

    public long Part2(string[] input)
    {
        var memory = ProcessInput(input);

        // PrintMemory(memory);
        var node = memory.Last;

        while (node != null)
        {
            var memorySegment = node.Value;

            if (memorySegment is FreeSpaceSegment)
            {
                node = node.Previous;
                continue;
            }

            var fileSegment = node.Value as FileSegment;

            var found = FindFreeSpaceForFile(memory, node, out var eligibleNode);

            if (!found)
            {
                node = node.Previous;
                continue;
            }

            // Update data on current file
            var freeSpaceSegment = eligibleNode?.Value;

            fileSegment!.StartPosition = freeSpaceSegment!.StartPosition;

            eligibleNode!.Value = fileSegment;

            // Check if there is remaining free space
            if (freeSpaceSegment.Length - fileSegment.Length >= 0)
            {
                freeSpaceSegment.Length -= fileSegment.Length;
                freeSpaceSegment.StartPosition += fileSegment.Length;
                memory.AddAfter(eligibleNode, freeSpaceSegment);
            }

            // Replace current file with free space

            node.Value = new FreeSpaceSegment
            {
                StartPosition = fileSegment.StartPosition,
                Length = fileSegment.Length
            };

            node = node.Previous;

            // PrintMemory(memory);
        }

        // PrintMemory(memory);

        return ComputeChecksum(memory);
    }


    bool FindFreeSpaceForFile(LinkedList<MemorySegment> memory, LinkedListNode<MemorySegment> fileSegment,
        out LinkedListNode<MemorySegment>? freeSpaceSegment)
    {
        var currentNode = memory.First;
        freeSpaceSegment = null;
        while (currentNode != fileSegment)
        {
            if (currentNode?.Value is FreeSpaceSegment && currentNode.Value.Length >= fileSegment.Value.Length)
            {
                freeSpaceSegment = currentNode;
                return true;
            }

            currentNode = currentNode?.Next;
        }

        return false;
    }

    void PrintMemory(LinkedList<MemorySegment> memorySegments)
    {
        foreach (var memorySegment in memorySegments)
        {
            if (memorySegment is FileSegment fileSegment)
            {
                Console.Write(new string(fileSegment.FileId.ToString()[0], fileSegment.Length));
            }
            else
            {
                Console.Write(new string('.', memorySegment.Length));
            }
        }

        Console.WriteLine();
    }

    long ComputeChecksum(LinkedList<MemorySegment> memorySegments)
    {
        long checksum = 0;
        foreach (var memorySegment in memorySegments)
        {
            if (memorySegment is not FileSegment fileSegment) continue;
            for (var i = fileSegment.StartPosition; i < fileSegment.StartPosition + fileSegment.Length; i++)
            {
                checksum += i * fileSegment.FileId;
            }
        }

        return checksum;
    }

    LinkedList<MemorySegment> ProcessInput(string[] input)
    {
        var memory = new LinkedList<MemorySegment>();
        var currentMemoryPosition = 0;
        var currentFileId = 0;

        for (var i = 0; i < input[0].Length; i++)
        {
            var len = input[0][i] - '0';

            if (i % 2 == 0) // file
            {
                var file = new FileSegment
                {
                    StartPosition = currentMemoryPosition,
                    Length = len,
                    FileId = currentFileId++
                };

                memory.AddLast(file);
            }
            else // free space
            {
                var freeSpace = new FreeSpaceSegment
                {
                    StartPosition = currentMemoryPosition,
                    Length = len
                };

                memory.AddLast(freeSpace);
            }

            currentMemoryPosition += len;
        }

        return memory;
    }


}

public class MemorySegment
{
    public int StartPosition { get; set; }
    public int Length { get; set; }
}

public class FileSegment : MemorySegment
{
    public int FileId { get; set; }
}

internal class FreeSpaceSegment : MemorySegment;