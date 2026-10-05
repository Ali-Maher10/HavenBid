import { AxiosError } from "axios";
import Problem from "./types/Problem";

type Args = {
    error: AxiosError<Problem>;
}

const ValidationSummary = ({ error }: Args) => {
  if (error.response?.status !== 400) return <></>;
  const errors = error.response?.data.errors;
  return (
    <div className="validation-summary" role="alert">
      <p>Fix these problems and save again:</p>
      <ul>
        {Object.entries(errors).map(([key, value]) => (
          <li key={key}>
            {key}: {value.join(", ")}
          </li>
        ))}
      </ul>
    </div>
  );
};
export default ValidationSummary;