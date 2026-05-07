import { useState } from 'react';

export function AgregarPaciente() {
  const [form, setForm] = useState({
    nombre: '',
    apellido: '',
    ci: '',
    objetivo: '',
    alergias: '',
    pesoInicial: 0,
    tallaInicial: 0
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    if (!form.nombre) { alert('El nombre es obligatorio'); return; }
    if (!form.apellido) { alert('El apellido es obligatorio'); return; }
    if (!form.ci) { alert('El CI es obligatorio'); return; }
    if (form.ci.length !== 7) { alert('El CI debe tener exactamente 7 caracteres'); return; }
    if (!form.objetivo) { alert('El objetivo es obligatorio'); return; }
    if (!form.pesoInicial) { alert('El peso es obligatorio'); return; }
    if (!form.tallaInicial) { alert('La talla es obligatoria'); return; }

    fetch('http://localhost:5243/api/paciente', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        ...form,
        pesoInicial: parseFloat(form.pesoInicial.toString()),
        tallaInicial: parseFloat(form.tallaInicial.toString())
      })
    })
      .then(res => res.json())
      .then(() => alert('Paciente registrado correctamente'))
      .catch(() => alert('Error al registrar el paciente'));
  };

  return (
    <div className="mb-4">
      <h4>Agregar Paciente</h4>
      <div className="row g-3">
        <div className="col-md-4">
          <input className="form-control" name="nombre" placeholder="Nombre" onChange={handleChange} />
        </div>
        <div className="col-md-4">
          <input className="form-control" name="apellido" placeholder="Apellido" onChange={handleChange} />
        </div>
        <div className="col-md-4">
          <input className="form-control" name="ci" placeholder="CI (7 caracteres)" maxLength={7} onChange={handleChange} />
        </div>
        <div className="col-md-4">
          <input className="form-control" name="objetivo" placeholder="Objetivo" onChange={handleChange} />
        </div>
        <div className="col-md-4">
          <input className="form-control" name="alergias" placeholder="Alergias (opcional)" onChange={handleChange} />
        </div>
        <div className="col-md-2">
          <input className="form-control" name="pesoInicial" placeholder="Peso (kg)" type="number" onChange={handleChange} />
        </div>
        <div className="col-md-2">
          <input className="form-control" name="tallaInicial" placeholder="Talla (m)" type="number" onChange={handleChange} />
        </div>
        <div className="col-12">
          <button className="btn btn-success" onClick={handleSubmit}>Registrar Paciente</button>
        </div>
      </div>
    </div>
  );
}