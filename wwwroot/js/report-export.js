window.compendioExport = window.compendioExport || {};

window.compendioExport.downloadJson = function (filename, jsonContent) {
    const blob = new Blob([jsonContent], { type: "application/json;charset=utf-8" });
    const url = URL.createObjectURL(blob);
    const a = document.createElement("a");
    a.href = url;
    a.download = filename || "relatorio-ingestao.json";
    document.body.appendChild(a);
    a.click();
    a.remove();
    URL.revokeObjectURL(url);
};
