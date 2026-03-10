import json
with open('audit_clean_report.json') as f:
    data = json.load(f)
files = data['all_files']
# files is a list of dicts with keys: file, formulas, variaveis, missing_formula, missing_variavel
def count_issues(d):
    return sum(len(v) for v in d.get('missing_formula', {}).values()) + \
           sum(len(v) for v in d.get('missing_variavel', {}).values())

files_with_issues = [d for d in files if count_issues(d) > 0]
files_with_issues.sort(key=count_issues, reverse=True)
print("=== Top 15 arquivos com mais issues ===")
for d in files_with_issues[:15]:
    total = count_issues(d)
    print(f'{d["file"]}: formulas={d["formulas"]}, issues={total}')
    for field, items in d.get('missing_formula', {}).items():
        print(f'  formula.{field}: {len(items)}')
    for field, items in d.get('missing_variavel', {}).items():
        print(f'  variavel.{field}: {len(items)}')
