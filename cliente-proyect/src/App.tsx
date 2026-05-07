import { Layout } from './layout/Layout'
import { ListaPacientes } from './componentes/Pacientes/ListaPacientes'
import { AgregarPaciente } from './componentes/Pacientes/AgregarPaciente'

function App() {
  return (
    <Layout>
      <div className="mb-4">
        <span className="badge bg-success mb-2">Endpoint</span>
        <h2 className="h4">Pacientes registrados</h2>
        <p className="text-muted mb-0">Consulta datos desde el endpoint de pacientes.</p>
      </div>
      <AgregarPaciente />
      <ListaPacientes />
    </Layout>
  )
}

export default App