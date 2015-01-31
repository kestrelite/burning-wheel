require("stringtools");

fileparser = {debug = false}

function fileparser.get_classes(lineText)
	local inClass = false;
	classTable = {};
	workingTable = {};
	for lineID, line in pairs(lineText) do
		workingTable[#workingTable + 1] = line;

		if stringtools.starts(line,"C") then
			assert(inClass == false, "C before EC in file on line " .. lineID);
			inClass = true;
		end

		if stringtools.starts(line, "EC") then
			assert(inClass == true, "EC before C in file on line " .. lineID);
			inClass = false;
			if #workingTable > 0 then classTable[#classTable + 1] = workingTable; end
			workingTable = {};
		end
	end

	if fileparser.debug then
		for i,v in ipairs(classTable) do
			print(i)
			for i2,v2 in ipairs(v) do
				print("\t",i2,v2);
			end
		end
	end

	return classTable
end

function fileparser.get_lines(file)
	assert(file ~= nil and type(file) == "string");

	lineText = {}
	io.input(file);
	while true do 
		t = io.lines()();
		if t == nil then break else 
			t = stringtools.strip_comments(t); 
			t = stringtools.trim(t); 
			if t ~= "" then lineText[#lineText+1] = t end
		end 
	end
	return lineText;
end

function fileparser.enable_debugging()
	fileparser.debug = true;
end

function fileparser.disable_debugging()
	fileparser.debug = false;
end