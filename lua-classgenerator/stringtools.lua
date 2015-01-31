stringtools = {}

function stringtools.trim(string)
	assert(string ~= nil, "Cannot trim nil string");
	return (string:gsub("^%s*(.-)%s*$", "%1"))
end

function stringtools.strip_comments(string) 
	assert(string ~= nil, "Cannot strip nil string");
	return (string:gsub("\#(.*)", ""));
end

function stringtools.starts(String,Start)
	assert(String ~= nil and Start ~= nil, "Needs non-nil arguments")
 	return string.sub(String,1,string.len(Start))==Start
end

function stringtools.ends(String,End)
	assert(String ~= nil and End ~= nil, "Needs non-nil arguments")
	return End=='' or string.sub(String,-string.len(End))==End
end

function stringtools.tokenize(string)
	assert(string ~= nil, "Cannot tokenize nil string")
	retTable = {}
	for i in string.gmatch(string, "[a-zA-Z0-9]+") do
		retTable[#retTable + 1] = i;
	end
	return retTable;
end

function stringtools.mergestringtable(stringt1, stringt2)
	assert(stringt1 ~= nil and stringt2 ~= nil, "String tables can't be nil")
	assert(type(stringt1) == "table" and type(stringt2) == "table", "String tables must be tables")

	retTable = {}

	for i,v in ipairs(stringt1) do
		assert(type(v) == "string", "Non-string element in stringt1")
		retTable[#retTable + 1] = v;
	end

	for i,v in ipairs(stringt2) do
		assert(type(v) == "string", "Non-string element in stringt2")
		retTable[#retTable + 1] = v;
	end

	return retTable
end