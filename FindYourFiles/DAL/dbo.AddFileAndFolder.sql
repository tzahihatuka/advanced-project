CREATE PROCEDURE AddFileAndFolder  
  ( @FolderName nvarchar(400),   
    @FileName nvarchar(400),
	@FileAndFolder nvarchar(800))   
AS   

    INSERT INTO SearchResult (SearchfileResult,SearchFolderResult,FolderAndFile)
	VALUES ( @FileName, @FolderName,@FileAndFolder)