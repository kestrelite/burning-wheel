require("fileparser");
require("filewriter");
require("stringtools");
require("classparser");

lineFeed = fileparser.get_lines("classlist.txt");
classTable = fileparser.get_classes(lineFeed);

classesToWrite = {}

for _,class in pairs(classTable) do
	classCode = classparser.parseToCSh(class)
	assert(#classCode == 0 or (#classCode > 0 and classCode.classname ~= nil), "Class name did not transfer")
	if classCode.classname ~= nil then classesToWrite[#classesToWrite + 1] = classCode; end
end

os.execute("mkdir output");
for _,classLines in pairs(classesToWrite) do
	if filewriter.isOpen() then filewriter.close() end
	filewriter.open("output\\".. classLines.classname ..".cs")

	for _,codeLine in ipairs(classLines) do
		filewriter.write_line(codeLine)
	end
end