interface PacienteProps {
  nombre: string;
  apellido: string;
  ci: string;
  objetivo: string;
  alergias: string | null;
  pesoInicial: number;
  tallaInicial: number;
}

export function Paciente({ nombre, apellido, ci, objetivo, alergias, pesoInicial, tallaInicial }: PacienteProps) {
  return (
    <li className="list-group-item">
      <h5>{nombre} {apellido}</h5>
      <p className="mb-1"><strong>CI:</strong> {ci}</p>
      <p className="mb-1"><strong>Objetivo:</strong> {objetivo}</p>
      <p className="mb-1"><strong>Alergias:</strong> {alergias ?? 'Ninguna'}</p>
      <p className="mb-0"><strong>Peso:</strong> {pesoInicial} kg — <strong>Talla:</strong> {tallaInicial} m</p>
    </li>
  );
}