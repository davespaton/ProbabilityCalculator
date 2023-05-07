type ProbabilityInputProps = {
    value: number;
    onChange: (value: number) => void;
    name: string;
}

const ProbabilityInput = (props: ProbabilityInputProps) => {

    const { onChange, value } = props;
    return (
        <span className="flex flex-col">
            <label 
                className="text-sm font-bold"
                htmlFor={props.name}>Probability {props.name}
            </label>
            <input
                className="border border-gray-400 p-2 rounded-sm "
                id={props.name}
                type={"number"}
                value={value}
                onChange={(event) => onChange(parseFloat(event.currentTarget.value))}
                max={1.0}
                min={0.0}
                step={0.01} />
        </span>
    );
};

export default ProbabilityInput;