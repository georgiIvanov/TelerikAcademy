function traverse(element) {
    function traverseElement(element, spacing) {
        var nodeName = element.nodeName;
        var id = (element.id ? " with id: " + element.id : "");
        var className = (element.className ? " with class: " + element.className : "");
        console.log(spacing + nodeName + id + className);

        for (var i = 0, len = element.childNodes.length; i < len; i += 1) {
            var child = element.childNodes[i];
            if (child.nodeType === 1) {
                traverseElement(child, spacing + "--");
            }
        }
        console.log(spacing + "/" + element.nodeName);
    }
    traverseElement(element, "");
}
