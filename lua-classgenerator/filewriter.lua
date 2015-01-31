filewriter = {debug = false, strict = true, inuse = false}

function filewriter.open(filename) 
	assert(not(filewriter.strict and filewriter.inuse), "File open called when file already open")
	filewriter.inuse = true;
	assert(io.output(filename))
end

function filewriter.close()
	assert(filewriter.inuse, "File close called when no file open")
	filewriter.inuse = false;
	assert(io.close());
end

function filewriter.isOpen() 
	return filewriter.inuse
end

function filewriter.write_blankline()
	assert(filewriter.inuse, "No file open")
	io.write("\n");
end

function filewriter.write_line(line)
	assert(filewriter.inuse, "No file open")
	assert(line ~= nil, "Line cannot be nil");
	io.write(line.."\n");
end