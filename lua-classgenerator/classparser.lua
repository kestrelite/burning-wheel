require("classparsetable")
classparser = {namespace = nil}

function classparser.parseToCSh(classData)
	classCode = {}
	classMetadata = {}
	for _,v in pairs(classData) do
		tokenString = stringtools.tokenize(v)
		assert(classparsetable[tokenString[1]] ~= nil, "No class parse definition for token \"" .. tokenString[1] .. "\"")
		if tokenString[1] == "C" then 
			assert(classparser.namespace ~= nil, "Can't enter class without namespace definition") 
			assert(#tokenString == 2, "Class name missing")
			classMetadata.classname = tokenString[2]
		end

		if tokenString[1] == "NSP" then 
			assert(#tokenString == 2, "Line of invalid length")
			classparser.namespace = tokenString[2]
		end
		appendLines = classparsetable[tokenString[1]](tokenString);
		assert(type(appendLines) == "table");

		classCode = stringtools.mergestringtable(classCode, appendLines)
	end

	if(#classCode == 0) then return classCode; end --Only happens if classData is just a NSP 

	classCode = stringtools.mergestringtable({"using System;","","namespace "..classparser.namespace,"{"}, classCode)
	classCode[#classCode + 1] = "}"

	assert(classMetadata.classname ~= nil, "Something went wrong assigning class name!")
	classCode.classname = classMetadata.classname
	return classCode;
end