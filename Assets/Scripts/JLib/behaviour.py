import sys
import os.path


def generate_behaviour(class_data):
	name = class_data[:class_data.find(": ")]
	class_name = name
	if name.rfind("/") >= 0:
		class_name = name[name.rfind("/") + 1:]
	properties = class_data[len(name) + 2:].split(", ")
	property_names = []

	#print properties

	imports = ["System", "UnityEngine"]
	
	imports_str = ""

	class_str = "public class " + class_name + " : JBehaviour\n{\n"
	
	properties_str = ""
	
	init_str = "\tpublic void Init("
	
	init_assign_str = ""
	
	end_top_str = "\t\t//// ABOVE GENERATED FOR //// \"" + class_data + "\" ////\n"
	
	start_bottom_str = "\t//// BELOW GENERATED FOR //// \"" + class_data + "\" \\\\\\\\\n"
	
	add_to_str = "\tpublic static " + class_name + " AddTo(GameObject newGameObject, "
	
	add_to_str2 = "\tpublic static " + class_name + " AddTo(Component component, "
	
		
	for p in properties:
		if p.find("Image") >= 0 or p.find("Text") >= 0:
			imports.append("UnityEngine.UI")
		elif p.find("Dictionary") is not -1 or p.find("List") is not -1:
			imports.append("System.Collections.Generic")
		elif p.find("UnityAction") is not -1:
			imports.append("UnityEngine.Events")
			
		if len(p.split(" ")) > 2:
			properties_str += "\t" + p + ";\n"
			
		parameter = " ".join(p.split(" ")[-2:])
		p_name = p.split(" ")[-1]
		property_names.append(p_name)
		
		init_str += parameter + ", "
		if len(p.split(" ")) > 2:
			init_assign_str += "\t\tthis." + p_name + " = " + p_name + ";\n"
		add_to_str += parameter + ", "
		add_to_str2 += parameter + ", "
	
	for i in imports:
		imports_str += "using " + i + ";\n"
	imports_str += "\n"
	
	init_str = init_str[:-2] + ")\n\t{\n"
	
	properties_str += "\n"
	
	add_to_str = add_to_str[:-2] + ")\n\t{\n\t\tvar behaviour = newGameObject.AddComponent<" + class_name + ">();\n\t\tbehaviour.Init("
	for p_name in property_names:
		add_to_str += p_name + ", "
	add_to_str = add_to_str[:-2] + ");\n\t\treturn behaviour;\n\t}\n\n"
	
	add_to_str2 = add_to_str2[:-2] + ")\n\t{\n\t\treturn AddTo(component.gameObject, "
	for p_name in property_names:
		add_to_str2 += p_name + ", "
	add_to_str2 = add_to_str2[:-2] + ");\n\t}\n"
	
	top_str = imports_str + class_str + properties_str + init_str + init_assign_str + end_top_str
	bottom_str = start_bottom_str + add_to_str + add_to_str2 + "\n}\n"
	
	dir = os.path.dirname(__file__)
	rel_file_path = "../" + name + ".cs"
	file_path = os.path.join(dir, rel_file_path)
	if os.path.isfile(file_path):
		# edit
		class_file = open(file_path, "r+")
		class_file_str = class_file.read()
		top_idx = class_file_str.find("//// ABOVE GENERATED FOR ////")
		bottom_idx = class_file_str.find("//// BELOW GENERATED FOR ////")
		if top_idx is -1 or bottom_idx is -1:
			class_file.close()
			print "ERROR: Can't find generation dividers"
			return
		top_idx = class_file_str.find("\n", top_idx) + 1
		bottom_idx = class_file_str.rfind("\n", 0, bottom_idx)
		file_middle = class_file_str[top_idx:bottom_idx]
		class_file.seek(0)
		class_file.truncate()
		class_file.write(top_str + file_middle + bottom_str)
		class_file.close()
	else:
		# new
		class_file = open(file_path, "w")
		class_file.write(top_str + "\n\n\t}\n\n\n" + bottom_str)
		class_file.close()
		
	
	return top_str, bottom_str

generate_behaviour(sys.argv[1])