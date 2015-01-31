require("fileparser");
require("filewriter");
require("stringtools");
require("classparser");

lineFeed = fileparser.get_lines("classlist.txt");
classTable = fileparser.get_classes(lineFeed);

for _,class in pairs(classTable) do
	outData = classparser.parseToCSh(class)
	for i,v in ipairs(outData) do print(i,v) end
end
