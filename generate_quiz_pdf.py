QUIZ = [
    ("Q1 — Rapid app deployment",
     "Your startup needs to deploy a web app quickly with minimal ops overhead and automatic scaling.",
     ["IaaS", "PaaS", "SaaS", "FaaS"],
     "PaaS",
     "PaaS provides a managed runtime, build/deploy workflow, and autoscaling so developers focus on code instead of servers."),

    ("Q2 — Full control & compliance",
     "You must run legacy software needing custom OS config, specific network setups, and full infrastructure control.",
     ["IaaS", "PaaS", "SaaS", "FaaS"],
     "IaaS",
     "IaaS gives raw VMs, networking, and storage control to configure OS and compliance requirements."),

    ("Q3 — Off-the-shelf business app",
     "You want a hosted CRM with standard features, low customization, and no platform management.",
     ["IaaS", "PaaS", "SaaS", "FaaS"],
     "SaaS",
     "SaaS delivers a complete, provider-managed application—no infra, runtime, or app hosting work required."),

    ("Q4 — Event-driven small workloads",
     "You need to process uploaded images (resize/thumbnail) only when events occur; cost should match usage.",
     ["IaaS", "PaaS", "SaaS", "FaaS"],
     "FaaS",
     "FaaS (serverless functions) runs per-event, scales automatically, and you're billed per execution—ideal for sporadic, short tasks."),

    ("Q5 — Containerized microservices with orchestration",
     "Your team builds microservices in containers and wants managed orchestration but control over deployments.",
     ["IaaS", "PaaS", "CaaS", "FaaS"],
     "CaaS",
     "CaaS provides managed container platforms (k8s/managed clusters) combining deployment control with infrastructure management."),
]


def escape_paren(s: str) -> str:
    return s.replace('\\', '\\\\').replace('(', '\\(').replace(')', '\\)')


def build_pdf_bytes(lines):
    # Build a minimal PDF with one page and a Type1 Helvetica font
    objs = []

    # Content stream: place text lines with simple operators
    text_ops = ['BT', '/F1 12 Tf', '72 750 Td']
    for ln in lines:
        esc = escape_paren(ln)
        text_ops.append(f'({esc}) Tj')
        text_ops.append('0 -14 Td')
    text_ops.append('ET')
    content_stream = '\n'.join(text_ops).encode('utf-8')

    # Objects
    objs.append((1, b'<< /Type /Catalog /Pages 2 0 R >>'))
    objs.append((2, b'<< /Type /Pages /Kids [3 0 R] /Count 1 >>'))
    objs.append((3, b'<< /Type /Page /Parent 2 0 R /Resources << /Font << /F1 4 0 R >> >> /MediaBox [0 0 612 792] /Contents 5 0 R >>'))
    objs.append((4, b'<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>'))
    objs.append((5, b'stream\n' + content_stream + b'\nendstream'))

    # Assemble PDF
    parts = []
    header = b'%PDF-1.4\n%\xe2\xe3\xcf\xd3\n'
    parts.append(header)

    xref_positions = []
    for objnum, body in objs:
        xref_positions.append(len(b''.join(parts)))
        parts.append(f"{objnum} 0 obj\n".encode('utf-8'))
        parts.append(body if isinstance(body, bytes) else body.encode('utf-8'))
        parts.append(b'\nendobj\n')

    xref_start = len(b''.join(parts))
    # xref table
    parts.append(b'xref\n')
    parts.append(f'0 {len(objs)+1}\n'.encode('utf-8'))
    parts.append(b'0000000000 65535 f \n')
    for pos in xref_positions:
        parts.append(f'{pos:010d} 00000 n \n'.encode('utf-8'))

    parts.append(b'trailer\n')
    parts.append(b'<< /Size ' + str(len(objs)+1).encode('utf-8') + b' /Root 1 0 R >>\n')
    parts.append(b'startxref\n')
    parts.append(str(xref_start).encode('utf-8') + b'\n')
    parts.append(b'%%EOF\n')

    return b''.join(parts)


def format_quiz_lines():
    lines = []
    lines.append('Cloud Service Model Selection — Short Scenario Quiz')
    lines.append('')
    for idx, (title, prompt, options, answer, explanation) in enumerate(QUIZ, start=1):
        lines.append(f'{idx}. {title}')
        lines.append(prompt)
        lines.append('Options: ' + ' / '.join(options))
        lines.append('Answer: ' + answer)
        lines.append('Explanation: ' + explanation)
        lines.append('')
    return lines


def make_pdf(path='/workspaces/quiz/quiz.pdf'):
    pdf_bytes = build_pdf_bytes(format_quiz_lines())
    with open(path, 'wb') as f:
        f.write(pdf_bytes)


def make_text(path='/workspaces/quiz/quiz.txt'):
    text = '\n'.join(format_quiz_lines())
    with open(path, 'w', encoding='utf-8') as f:
        f.write(text)


if __name__ == '__main__':
    make_pdf()
    make_text()
