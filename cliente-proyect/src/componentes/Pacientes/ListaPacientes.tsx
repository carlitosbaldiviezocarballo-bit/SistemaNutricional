import { useState, useEffect } from 'react';
import { Paciente, Paciente as PacienteComponent } from './Pacientes';

type PacienteData = {
  nombre: string;
  apellido: string;
  ci: string;
  objetivo: string;
  alergias: string;
  pesoInicial: number;
  tallaInicial: number;
};

export function ListaPacientes() {
  const [pacientes, setPacientes] = useState<PacienteData[]>([]);
  const [cargando, setCargando] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetch('http://localhost:5243/api/paciente')
      .then(res => res.json())
      .then(data => {
        setPacientes(data);
        setCargando(false);
      })
      .catch(() => {
        setError('Error al cargar los pacientes');
        setCargando(false);
      });
  }, []);

  if (cargando) return <p>Cargando pacientes...</p>;
  if (error) return <p className="alert alert-danger">{error}</p>;

  return (
    <ul className="list-group">
      {pacientes.map((p, index) => (
        <Paciente
          key={index}
          nombre={p.nombre}
          apellido={p.apellido}
          ci={p.ci}
          objetivo={p.objetivo}
          alergias={p.alergias}
          pesoInicial={p.pesoInicial}
          tallaInicial={p.tallaInicial}
        />
      ))}
    </ul>
  );
}