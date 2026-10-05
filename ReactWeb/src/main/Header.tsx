import { Link } from 'react-router-dom'
import logo from './GloboLogo.png'

type Args={
    subtitle: string;
}
const Header = ({ subtitle }: Args) => {
  return (
    <header className="masthead">
      <div className="container masthead__inner">
        <Link to="/">
          <img src={logo} className="masthead__logo" alt="Globomantics home" />
        </Link>
        <p className="masthead__tagline" aria-label={subtitle}>
          {subtitle.split(" ").map((word, i) => (
            <span
              key={i}
              className="masthead__word"
              style={{ animationDelay: `${i * 0.12}s` }}
              aria-hidden="true"
            >
              {word}
            </span>
          ))}
        </p>
      </div>
    </header>
  );
}

export default Header
